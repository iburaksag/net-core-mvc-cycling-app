using System;
using CloudinaryDotNet.Actions;

namespace RunGroopWebApp.Data.Abstract
{
	public interface IPhotoService
	{
		Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}




