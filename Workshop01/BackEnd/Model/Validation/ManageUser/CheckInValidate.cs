using FluentValidation;
using Workshop01.BackEnd.Model.Request.ManageUser;

namespace Workshop01.BackEnd.Model.Validation.ManageUser
{
    public class CheckInValidate
    {
    }

    public class InsertCheckInValidate : AbstractValidator<InsertCheckInRequest>
    {
        public InsertCheckInValidate() {
            //RuleFor(R => R.StudentId).NotEmpty().WithMessage("{PropertyName} ต้องระบุค่า").NotNull().WithMessage("{PropertyName} ต้องไม่ null");
        }
    }
}
