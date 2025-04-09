using Microsoft.AspNetCore.JsonPatch;
using System.ComponentModel.DataAnnotations;

namespace Services.Helpers
{
    public static class PatchHelper
    {
        public static void ApplyPatch<T>(JsonPatchDocument<T> originalPatch, T targetObject, params string[] blockedPaths) where T : class
        {
            var safePatch = new JsonPatchDocument<T>();

            foreach (var op in originalPatch.Operations)
            {
                var path = op.path?.Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(path))
                {
                    if (!path.StartsWith("/")) path = "/" + path;

                    if (blockedPaths.Select(p => p.ToLower()).Contains(path))
                        throw new ArgumentException($"You cannot patch the '{path.TrimStart('/')}' field.");
                }

                safePatch.Operations.Add(op);
            }

            try
            {
                safePatch.ApplyTo(targetObject);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid value type in patch request. " + ex.Message);
            }

            var validationContext = new ValidationContext(targetObject);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(targetObject, validationContext, validationResults, true);
            if (!isValid)
            {
                var errors = validationResults.Select(r => r.ErrorMessage);
                throw new ArgumentException("Validation failed: " + string.Join(" | ", errors));
            }
        }
    }
}
