namespace BookBaazar.Application.AWS
{
    public interface IStorageService
    {
        Task<S3Response> UploadFileAsync(S3Object s3obj, AwsCredentials awsCredentials);
    }
}
