using FluentValidation;
using WaggyProject.Entities;

namespace WaggyProject.Validations
{
    public class TestimonialValidator: AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad Boş Bırakılamaz!");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Boş Bırakılamaz!")
                                    .MinimumLength(50).WithMessage("Yorum en az 50 karakterden oluşmalıdır.")
                                    .MaximumLength(150).WithMessage("Yorum en fazla 150 karakterden oluşmalıdır.");



        }

    }
}
