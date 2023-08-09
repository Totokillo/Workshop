using FluentValidation;
using Workshop01.BackEnd.Model.Request.ManageUser;

namespace Workshop01.BackEnd.Model.Validation.ManageUser;

    public class ManageUserValidate
    {
    }

    public class InsertManageUserValidate : AbstractValidator<InsertManageUserRequest>
{
    public InsertManageUserValidate()
    {
        RuleFor(R => R.StudentId).NotEmpty().WithMessage("{PropertyName} ต้องระบุค่า").NotNull().WithMessage("{PropertyName} ต้องไม่ null");
    }
}

    public class UpdateManageUserValidate : AbstractValidator<UpdateManageUserRequest>
{
    public UpdateManageUserValidate()
    {
        RuleFor(R => R.Id).NotEmpty().WithMessage("{PropertyName} ต้องระบุค่า").NotNull().WithMessage("{PropertyName} ต้องไม่ null");
    }
}

    public class DeleteManageUserValidate : AbstractValidator<DeleteManageUserRequest>
{
    public DeleteManageUserValidate()
    {
        RuleFor(R => R.Id).NotEmpty().WithMessage("{PropertyName} ต้องระบุค่า").NotNull().WithMessage("{PropertyName} ต้องไม่ null");
    }
}

