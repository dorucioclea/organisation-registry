﻿namespace OrganisationRegistry.Function
{
    using Commands;
    using Infrastructure.Commands;
    using Infrastructure.Domain;
    using Microsoft.Extensions.Logging;

    public class FunctionTypeCommandHandlers :
        BaseCommandHandler<FunctionTypeCommandHandlers>,
        ICommandHandler<CreateFunctionType>,
        ICommandHandler<UpdateFunctionType>
    {
        private readonly IUniqueNameValidator<FunctionType> _uniqueNameValidator;

        public FunctionTypeCommandHandlers(
            ILogger<FunctionTypeCommandHandlers> logger,
            ISession session,
            IUniqueNameValidator<FunctionType> uniqueNameValidator) : base(logger, session)
        {
            _uniqueNameValidator = uniqueNameValidator;
        }

        public void Handle(CreateFunctionType message)
        {
            if (_uniqueNameValidator.IsNameTaken(message.Name))
                throw new NameNotUniqueException();

            var functionType = new FunctionType(message.FunctionTypeId, message.Name);

            Session.Add(functionType);
            Session.Commit();
        }

        public void Handle(UpdateFunctionType message)
        {
            if (_uniqueNameValidator.IsNameTaken(message.FunctionTypeId, message.Name))
                throw new NameNotUniqueException();

            var functionType = Session.Get<FunctionType>(message.FunctionTypeId);

            functionType.Update(message.Name);
            Session.Commit();
        }
    }
}