using CommunityToolkit.Mvvm.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Tutor.Mobile.ViewModels;

public partial class ViewModel : ObservableObject
{
    private IEnumerable<PropertyInfo> validationErrorProperties;
    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;
    public bool IsNotBusy => IsBusy;

    private readonly object _isBusyLock = new();
    protected bool CheckIsBusy()
    {
        lock (_isBusyLock)
        {
            if (IsBusy)
            {
                return true;
            }

            IsBusy = true;
            return false;
        }
    }

    protected ValidationResult Validate<TModel>(TModel model, IValidator<TModel> validator)
    {
        validationErrorProperties ??= FindValidationErrors().ToArray();

        foreach (var errorProperty in validationErrorProperties)
        {
            errorProperty.SetValue(this, null);
        }

        var validationResult = validator.Validate(model);

        if (validationResult.IsValid)
        {
            return validationResult;
        }

        var groppedErrors = validationResult.Errors.GroupBy(e => e.PropertyName);
        foreach (var group in groppedErrors)
        {
            var property = validationErrorProperties.FirstOrDefault(p => p.Name == $"{group.Key}ValidationErrors");

            if (property is null)
            {
                continue;
            }

            var joinedErrors = string.Join(". ", group.Select(e => e.ErrorMessage));
            property.SetValue(this, joinedErrors);
        }

        return validationResult;
    }

    private IEnumerable<PropertyInfo> FindValidationErrors()
    {
        foreach (var property in GetType().GetProperties())
        {
            if (property.Name.EndsWith("ValidationErrors"))
            {
                yield return property;
            }
        }
    }
}
