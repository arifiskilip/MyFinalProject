using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() //ctrl + k + d ------> düzenleme
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); // 0 dan büyük olmalı.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); // ıd 1 için, 10 dan daha büyük veya eşit.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler 'A' harfi ile başlamalı."); // A ile başlıyor mu ?

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
