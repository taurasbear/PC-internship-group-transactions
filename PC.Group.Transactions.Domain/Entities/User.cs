﻿namespace PC.Group.Transactions.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;

    public ICollection<Member> Members { get; set; } = new List<Member>();
}
