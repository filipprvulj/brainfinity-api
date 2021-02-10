using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brainfinity.Domain.ValidatorExtensions;

namespace Brainfinity.Domain.Validators
{
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        public FormFileValidator(IOptions<ImageOptions> imageOptions)
        {
            RuleFor(file => file.FileName)
                .ValidExtension(imageOptions.Value);
        }
    }
}