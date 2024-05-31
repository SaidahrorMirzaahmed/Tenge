using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenge.Service.Configurations;
using Tenge.WebApi.Models.Assets;

namespace Tenge.Service.Services.Assets.Assets;

public class FileModelValidator : AbstractValidator<AssetCreateModel>
{
    public FileModelValidator()
    {
        RuleFor(c => c.File).NotNull().WithMessage("File cannot be null.")
            .Must(file => file.Length > 0).WithMessage("File cannot be empty.");

        RuleFor(createModel => createModel.File.FileName)
            .Must((createModel, fileName) =>
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    return false;
                }

                switch (createModel.FileType)
                {
                    case FileType.Pictures:
                        return IsImageExtension(fileName);
                    case FileType.Videos:
                        return IsVideoExtension(fileName);
                    default:
                        return false;
                }
            })
            .WithMessage(createModel => GetMessageForFileType(createModel.FileType));
    }

    private bool IsImageExtension(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        if (string.IsNullOrEmpty(extension))
        {
            return false;
        }

        return extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".png", StringComparison.OrdinalIgnoreCase);
    }

    private bool IsVideoExtension(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        if (string.IsNullOrEmpty(extension))
        {
            return false;
        }

        return extension.Equals(".mp4", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".mov", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".avi", StringComparison.OrdinalIgnoreCase);
    }

    private string GetMessageForFileType(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.Pictures:
                return "The file must be a picture (JPG, JPEG, or PNG)";
            case FileType.Videos:
                return "The file must be a video (AVI, MOV, or MP4)";
            default:
                return "Invalid file type";
        }
    }
}