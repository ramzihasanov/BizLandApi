﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.ServiceDto
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class ServiceUpdateDtoValidator : AbstractValidator<ServiceUpdateDto>
    {
        public ServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            RuleFor(x => x.LogoUrl)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);


        }
    }
}