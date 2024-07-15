using BLL.DTO.PosDTO;
using BLL.Repositories.Pos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BBL.DTO.PosDTO.PosValidation
{
	public class PosValidation:AbstractValidator<AddPOSDTO>
	{
		private readonly IPosRepository _posRepository;


		public PosValidation(IPosRepository posRepository)
		{
			_posRepository = posRepository;
			

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.").Must(posRepository.UniqueName).WithMessage("Name must be unique"); 
				

			RuleFor(x => x.CellPhone).NotEmpty().WithMessage("Phone Number is required.")
						   .MinimumLength(9).WithMessage("PhoneNumber must not be less than 10 characters.")
						   .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.")
						   .Must(posRepository.UniqueTelephone).WithMessage("Name must be unique");


			RuleFor(x => x.Address)
				.NotNull().WithMessage("Adress is required.").Length(7, 100);

			RuleFor(p => p.Telephone)
						   .NotEmpty().WithMessage("Phone Number is required.")
						   .MinimumLength(9).WithMessage("PhoneNumber must not be less than 10 characters.")
						   .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.")
						   .Must(posRepository.UniqueTelephone).WithMessage("Name must be unique");


			RuleFor(p => p.CityName).NotEmpty().WithMessage("City is required");
			RuleFor(p => p.Brand).NotNull().WithMessage("Brand is required");
			RuleFor(p => p.Model).NotNull().WithMessage("Model is required");
			RuleFor(p => p.ConnectionType).NotNull().WithMessage("ConnectionType is required");

			RuleFor(p => p.MorningOperning).NotNull().WithMessage("MorningOperning is required");
			RuleFor(p => p.MorningClosing).NotNull().WithMessage("MorningClosing is required");
			RuleFor(p => p.AfternonClosing).NotNull().WithMessage("AfternonClosing is required");
			RuleFor(p => p.AfternoonOpening).NotNull().WithMessage("AfternoonOpening is required");

			RuleFor(x => x.SelectedDays).Must(x => x != null && x.Any()).WithMessage("Please select at least one day.");
		}
	}
		

}

	

