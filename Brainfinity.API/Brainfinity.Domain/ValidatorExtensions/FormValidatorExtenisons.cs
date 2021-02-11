using Brainfinity.Domain.Options;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Domain.ValidatorExtensions
{
    public static class FormValidatorExtenisons
    {
        public static IRuleBuilderOptions<T, TProperty> ValidExtension<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, ImageOptions imageOptions)
        {
            return ruleBuilder.Must(file => imageOptions.AllowedTypes.Any(opt => opt == Path.GetExtension(file.ToString())))
                .WithMessage("Ekstenzija fajla nije dozvoljena.");
        }
    }
}