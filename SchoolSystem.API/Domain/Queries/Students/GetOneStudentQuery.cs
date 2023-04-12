﻿using MediatR;
using SchoolSystem.API.Domain.Communication.Response;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Queries.Students
{
    public class GetOneStudentQuery : IRequest<SchoolResponse>
    {
        public int Id { get; init; }
        public GetOneStudentQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
