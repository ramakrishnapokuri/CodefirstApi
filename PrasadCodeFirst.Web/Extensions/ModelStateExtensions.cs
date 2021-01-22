using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;
using PrasadCodeFirst.Common;

namespace PrasadCodeFirst.Web.Extensions
{
    public static class ModelStateExtensions
    {
        public static string ToErrorString(this ModelStateDictionary modelState, bool camelCaseKeyName = true)
        {
            var errors = modelState
                .Where(x => x.Value.Errors.Any())
                .Select(kvp => string.Format("{0}", string.Join("|", kvp.Value.Errors.Select(e => e.ErrorMessage))));

            return string.Join("\n", errors);
        }

    }
}