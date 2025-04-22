using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hackathon.UserService.Binders;

public class EnumMemberModelBinder<T> : IModelBinder where T : struct, Enum
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var value = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).FirstOrDefault();

        if (value == null)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        foreach (var field in typeof(T).GetFields())
        {
            var attr = Attribute.GetCustomAttribute(field,
                typeof(EnumMemberAttribute)) as EnumMemberAttribute;

            if ((attr != null && attr.Value == value) || field.Name == value)
            {
                bindingContext.Result = ModelBindingResult.Success((T)field.GetValue(null));
                return Task.CompletedTask;
            }
        }

        bindingContext.ModelState.AddModelError(bindingContext.FieldName, $"The value '{value}' is not valid.");
        bindingContext.Result = ModelBindingResult.Failed();
        return Task.CompletedTask;
    }
}
