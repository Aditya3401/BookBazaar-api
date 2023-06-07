using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.AWS;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookBaazar.Application.Endpoints.AWS.Commands
{
    public class awsCommand : IRequest<S3Response>
    {
        public S3Object s3Obj { get; set; }
        public AwsCredentials cred { get; set; }
    }
}
