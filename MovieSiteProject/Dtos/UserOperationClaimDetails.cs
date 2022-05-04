﻿using MovieSiteProject.Core.Entities.Abstract;

namespace MovieSiteProject.Dtos
{
    public class UserOperationClaimDetails : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }

        public string Email { get; set; }
        public string OperationClaimName { get; set; }
    }
}
