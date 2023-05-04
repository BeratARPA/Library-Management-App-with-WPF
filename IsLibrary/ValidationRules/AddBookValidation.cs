using Database.Models;
using FluentValidation;
using IsLibrary.ViewModels;
using System;
using System.Windows;

namespace IsLibrary.ValidationRules
{
    public class AddBookValidation : AbstractValidator<AddBookViewModel>
    {
        public AddBookValidation()
        {
            ResourceDictionary language = new ResourceDictionary { Source = new Uri(Properties.Settings.Default.Language, UriKind.Relative) };

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(language["NameCannotEmpty"].ToString());

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage(language["CategoryCannotEmpty"].ToString());

            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage(language["SubjectCannotEmpty"].ToString());

            RuleFor(x => x.PrintingPlace)
                .NotEmpty()
                .WithMessage(language["PrintingPlaceCannotEmpty"].ToString());

            RuleFor(x => x.PrintCount)
                .NotEmpty()
                .WithMessage(language["PrintCountCannotEmpty"].ToString());

            RuleFor(x => x.PrintDate)
                .NotEmpty()
                .WithMessage(language["PrintDateCannotEmpty"].ToString());

            RuleFor(x => x.SupplyCategory)
                .NotEmpty()
                .WithMessage(language["SupplyCategoryCannotEmpty"].ToString());

            RuleFor(x => x.SupplyDate)
                .NotEmpty()
                .WithMessage(language["SupplyDateCannotEmpty"].ToString());

            RuleFor(x => x.PageCount)
                .NotEmpty()
                .WithMessage(language["PageCountCannotEmpty"].ToString());

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage(language["ImageCannotEmpty"].ToString());

            RuleFor(x => x.Barcode)
                .NotEmpty()
                .WithMessage(language["BarcodeCannotEmpty"].ToString());

        }
    }
}
