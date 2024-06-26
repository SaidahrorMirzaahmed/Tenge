﻿using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.Threading;
using System.Threading.Tasks;
using Tenge.Service.Services.Collections;
using Tenge.WebApi.Models.Items;

public class ItemCreateModelValidator : AbstractValidator<ItemCreateModel>
{
    public ItemCreateModelValidator(ICollectionService collectionService)
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x)
            .CustomAsync(async (item, context, cancellationToken) =>
            {
                var collection = await collectionService.GetAsync(item.CollectionId); // Assuming CollectionId is part of ItemCreateModel
                if (collection == null)
                {
                    context.AddFailure("Collection", "Collection not found.");
                    return;
                }

                if (!string.IsNullOrEmpty(collection.CustomString1) && string.IsNullOrEmpty(item.CustomString1Value))
                    context.AddFailure("CustomString1Value", "CustomString1Value should not be empty if Collection.CustomString1 is not empty.");

                if (!string.IsNullOrEmpty(collection.CustomString2) && string.IsNullOrEmpty(item.CustomString2Value))
                    context.AddFailure("CustomString2Value", "CustomString2Value should not be empty if Collection.CustomString2 is not empty.");

                if (!string.IsNullOrEmpty(collection.CustomString3) && string.IsNullOrEmpty(item.CustomString3Value))
                    context.AddFailure("CustomString3Value", "CustomString3Value should not be empty if Collection.CustomString3 is not empty.");

                if (!collection.CustomInt1.IsNullOrEmpty() && !item.CustomInt1Value.HasValue)
                    context.AddFailure("CustomInt1Value", "CustomInt1Value should not be null if Collection.CustomInt1 is not null.");

                if (!collection.CustomInt2.IsNullOrEmpty() && !item.CustomInt2Value.HasValue)
                    context.AddFailure("CustomInt2Value", "CustomInt2Value should not be null if Collection.CustomInt2 is not null.");

                if (!collection.CustomInt3.IsNullOrEmpty() && !item.CustomInt3Value.HasValue)
                    context.AddFailure("CustomInt3Value", "CustomInt3Value should not be null if Collection.CustomInt3 is not null.");

                if (!collection.CustomDate1.IsNullOrEmpty() && item.CustomDate1Value == default(DateTime))
                    context.AddFailure("CustomDate1Value", "CustomDate1Value should match the value in Collection.CustomDate1.");

                if (collection.CustomDate2.IsNullOrEmpty() && item.CustomDate2Value == default(DateTime))
                    context.AddFailure("CustomDate2Value", "CustomDate2Value should be the default value if Collection.CustomDate2 is null.");

                if (!collection.CustomDate3.IsNullOrEmpty() && item.CustomDate3Value == default(DateTime))
                    context.AddFailure("CustomDate3Value", "CustomDate3Value should match the value in Collection.CustomDate3.");
            });
    }
}


