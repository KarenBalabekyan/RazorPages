using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Extensions
{
    public static class FormFileExtensions
    {
        private const int DefaultBufferSize = 80 * 1024;

        /// <summary>
        /// Asynchronously saves the contents of an uploaded file.
        /// </summary>
        /// <param name="formFile">The <see cref="IFormFile"/>.</param>
        /// <param name="filePath">*/file real path</param>
        /// <param name="cancellationToken"></param>
        public static async Task SaveAsAsync(
            this IFormFile formFile,
            string filePath,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (formFile == null)
            {
                throw new ArgumentNullException(nameof(formFile));
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var inputStream = formFile.OpenReadStream();
                await inputStream.CopyToAsync(fileStream, DefaultBufferSize, cancellationToken);
            }
        }
    }
}