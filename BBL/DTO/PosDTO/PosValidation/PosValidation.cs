using BLL.DTO.PosDTO;
using BLL.Repositories.Pos;
using BLL.Repositories.User;
using FluentValidation;
using System.Linq;


namespace BBL.DTO.PosDTO.PosValidation
{
	public class PosValidation:AbstractValidator<AddPOSDTO>
	{
		private readonly IPosRepository posRepository;

		public PosValidation(IPosRepository posRepository)
		{
		   this.posRepository = posRepository;	


			

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.").Must(posRepository.UniqueName).WithMessage("Name must be unique"); 
				

			RuleFor(x => x.CellPhone).NotEmpty().WithMessage("Phone Number is required.")
						   .MinimumLength(9).WithMessage("PhoneNumber must not be less than 10 characters.")
						   .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.")
						   .Must(posRepository.UniqueTelephone).WithMessage("Name must be unique");


			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Adress is required.").Length(7, 100);

			RuleFor(p => p.Telephone)
						   .NotEmpty().WithMessage("Phone Number is required.")
						   .MinimumLength(9).WithMessage("PhoneNumber must not be less than 10 characters.")
						   .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.")
						   .Must(posRepository.UniqueTelephone).WithMessage("Name must be unique");


			RuleFor(p => p.CityName).NotEmpty().WithMessage("City is required");
			RuleFor(p => p.Brand).NotEmpty().WithMessage("Brand is required");
			RuleFor(p => p.Model).NotEmpty().WithMessage("Model is required");
			RuleFor(p => p.ConnectionType).NotEmpty().WithMessage("ConnectionType is required");

			RuleFor(p => p.MorningOperning).NotEmpty().WithMessage("MorningOperning is required");
			RuleFor(p => p.MorningClosing).NotEmpty().WithMessage("MorningClosing is required");
			RuleFor(p => p.AfternonClosing).NotEmpty().WithMessage("AfternonClosing is required");
			RuleFor(p => p.AfternoonOpening).NotEmpty().WithMessage("AfternoonOpening is required");

			RuleFor(x => x.SelectedDays).Must(x => x != null && x.Any()).WithMessage("Please select at least one day.");
		}
	}
		

}

	

