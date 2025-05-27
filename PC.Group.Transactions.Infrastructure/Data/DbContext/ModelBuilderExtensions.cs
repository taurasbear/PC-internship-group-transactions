namespace PC.Group.Transactions.Infrastructure.Data.DbContext;

using Microsoft.EntityFrameworkCore;
using PC.Group.Transactions.Domain.Entities;
using PC.Group.Transactions.Domain.Enums;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Data has been generated with the help of a LLM
        modelBuilder.Entity<User>().HasData
        (
            new User { Id = 1, Username = "Bearman" },
            new User { Id = 2, Username = "Bearwoman" },
            new User { Id = 3, Username = "Bearchild" },
            new User { Id = 4, Username = "Bearcub" },
            new User { Id = 5, Username = "Bearclaw" },
            new User { Id = 6, Username = "Bearpaw" }, // Not in any group
            new User { Id = 7, Username = "Bearhug" }
        );

        modelBuilder.Entity<Group>().HasData
        (
            new Group { Id = 1, Title = "Bear lovers" },
            new Group { Id = 2, Title = "Polar Bear Club" },
            new Group { Id = 3, Title = "Grizzly Gathering" },
            new Group { Id = 4, Title = "Panda Party" },
            new Group { Id = 5, Title = "Koala Krew" }
        );

        modelBuilder.Entity<Member>().HasData
        (
            // Group 1: Bear lovers (Users 1,2,3)
            new Member { Id = 1, UserId = 1, GroupId = 1 },
            new Member { Id = 2, UserId = 2, GroupId = 1 },
            new Member { Id = 3, UserId = 3, GroupId = 1 },
            // Group 2: Polar Bear Club (Users 2,3,4,5)
            new Member { Id = 4, UserId = 2, GroupId = 2 },
            new Member { Id = 5, UserId = 3, GroupId = 2 },
            new Member { Id = 6, UserId = 4, GroupId = 2 },
            new Member { Id = 7, UserId = 5, GroupId = 2 },
            new Member { Id = 18, UserId = 1, GroupId = 2 }, // Added User 1 to Group 2
            // Group 3: Grizzly Gathering (Users 1,4,5,7)
            new Member { Id = 8, UserId = 1, GroupId = 3 },
            new Member { Id = 9, UserId = 4, GroupId = 3 },
            new Member { Id = 10, UserId = 5, GroupId = 3 },
            new Member { Id = 11, UserId = 7, GroupId = 3 },
            // Group 4: Panda Party (Users 2,3,7)
            new Member { Id = 12, UserId = 2, GroupId = 4 },
            new Member { Id = 13, UserId = 3, GroupId = 4 },
            new Member { Id = 14, UserId = 7, GroupId = 4 },
            new Member { Id = 19, UserId = 1, GroupId = 4 }, // Added User 1 to Group 4
            // Group 5: Koala Krew (Users 4,5,7) -- User 1 is NOT a member
            new Member { Id = 15, UserId = 4, GroupId = 5 },
            new Member { Id = 16, UserId = 5, GroupId = 5 },
            new Member { Id = 17, UserId = 7, GroupId = 5 }
        );

        modelBuilder.Entity<Transaction>().HasData
        (
            // Group 1: Equally (Payer and debtors are members of Group 1)
            new Transaction { Id = 1, PayerId = 1, Amount = 33, Method = SplittingMethod.Equally, CreatedAt = DateTime.UtcNow.AddDays(-10) },
            // 2 more transactions for group 1 here
            new Transaction { Id = 6, PayerId = 2, Amount = 60, Method = SplittingMethod.Equally, CreatedAt = DateTime.UtcNow.AddDays(-9) },
            new Transaction { Id = 7, PayerId = 3, Amount = 90, Method = SplittingMethod.Dynamic, CreatedAt = DateTime.UtcNow.AddDays(-8) },

            // Group 2: Percentage (Payer and debtors are members of Group 2)
            new Transaction { Id = 2, PayerId = 18, Amount = 100, Method = SplittingMethod.Percentage, CreatedAt = DateTime.UtcNow.AddDays(-8) },
            // 1 more transaction for group 2
            new Transaction { Id = 8, PayerId = 7, Amount = 80, Method = SplittingMethod.Percentage, CreatedAt = DateTime.UtcNow.AddDays(-7) },

            // Group 3: Dynamic (Payer and debtors are members of Group 3)
            new Transaction { Id = 3, PayerId = 9, Amount = 75, Method = SplittingMethod.Dynamic, CreatedAt = DateTime.UtcNow.AddDays(-6) },

            // Group 4: Equally (Payer and debtors are members of Group 4)
            new Transaction { Id = 4, PayerId = 14, Amount = 60, Method = SplittingMethod.Equally, CreatedAt = DateTime.UtcNow.AddDays(-4) },
            // 1 more transaction for group 4
            new Transaction { Id = 9, PayerId = 12, Amount = 45, Method = SplittingMethod.Equally, CreatedAt = DateTime.UtcNow.AddDays(-3) },

            // Group 5: Percentage (Payer and debtors are members of Group 5)
            new Transaction { Id = 5, PayerId = 16, Amount = 90, Method = SplittingMethod.Percentage, CreatedAt = DateTime.UtcNow.AddDays(-2) }
        );

        modelBuilder.Entity<TransactionPortion>().HasData
        (
            // Transaction 1: Equally (Group 1, 3 members)
            new TransactionPortion { Id = 1, DebtorId = 1, TransactionId = 1, Amount = 11 },
            new TransactionPortion { Id = 2, DebtorId = 2, TransactionId = 1, Amount = 11 },
            new TransactionPortion { Id = 3, DebtorId = 3, TransactionId = 1, Amount = 11 },

            // Transaction 6: Equally (Group 1, 3 members)
            new TransactionPortion { Id = 18, DebtorId = 1, TransactionId = 6, Amount = 20 },
            new TransactionPortion { Id = 19, DebtorId = 2, TransactionId = 6, Amount = 20 },
            new TransactionPortion { Id = 20, DebtorId = 3, TransactionId = 6, Amount = 20 },

            // Transaction 7: Equally (Group 1, 2 members)
            //new TransactionPortion { Id = 21, DebtorId = 1, TransactionId = 7, Amount = 30 },
            new TransactionPortion { Id = 22, DebtorId = 2, TransactionId = 7, Amount = 45 },
            new TransactionPortion { Id = 23, DebtorId = 3, TransactionId = 7, Amount = 45 },

            // Transaction 2: Percentage (Group 2, 5 members: 32%, 24%, 20%, 16%, 8%)
            new TransactionPortion { Id = 4, DebtorId = 4, TransactionId = 2, Amount = 32 }, // MemberId 4 (User 2)
            new TransactionPortion { Id = 5, DebtorId = 5, TransactionId = 2, Amount = 24 }, // MemberId 5 (User 3)
            new TransactionPortion { Id = 6, DebtorId = 6, TransactionId = 2, Amount = 20 }, // MemberId 6 (User 4)
            new TransactionPortion { Id = 7, DebtorId = 7, TransactionId = 2, Amount = 16 }, // MemberId 7 (User 5)
            new TransactionPortion { Id = 31, DebtorId = 18, TransactionId = 2, Amount = 8 }, // MemberId 18 (User 1)

            // Transaction 8: Percentage (Group 2, 5 members: 20% each)
            new TransactionPortion { Id = 24, DebtorId = 4, TransactionId = 8, Amount = 16 },
            new TransactionPortion { Id = 25, DebtorId = 5, TransactionId = 8, Amount = 16 },
            new TransactionPortion { Id = 26, DebtorId = 6, TransactionId = 8, Amount = 16 },
            new TransactionPortion { Id = 27, DebtorId = 7, TransactionId = 8, Amount = 16 },
            new TransactionPortion { Id = 32, DebtorId = 18, TransactionId = 8, Amount = 16 },

            // Transaction 3: Dynamic (Group 3, 4 members: custom amounts)
            new TransactionPortion { Id = 8, DebtorId = 8, TransactionId = 3, Amount = 10 },
            new TransactionPortion { Id = 9, DebtorId = 9, TransactionId = 3, Amount = 25 },
            new TransactionPortion { Id = 10, DebtorId = 10, TransactionId = 3, Amount = 20 },
            new TransactionPortion { Id = 11, DebtorId = 11, TransactionId = 3, Amount = 20 },

            // Transaction 4: Equally (Group 4, 4 members)
            new TransactionPortion { Id = 12, DebtorId = 12, TransactionId = 4, Amount = 15 },
            new TransactionPortion { Id = 13, DebtorId = 13, TransactionId = 4, Amount = 15 },
            new TransactionPortion { Id = 14, DebtorId = 14, TransactionId = 4, Amount = 15 },
            new TransactionPortion { Id = 33, DebtorId = 19, TransactionId = 4, Amount = 15 },

            // Transaction 9: Equally (Group 4, 4 members)
            new TransactionPortion { Id = 28, DebtorId = 12, TransactionId = 9, Amount = 11.25m },
            new TransactionPortion { Id = 29, DebtorId = 13, TransactionId = 9, Amount = 11.25m },
            new TransactionPortion { Id = 30, DebtorId = 14, TransactionId = 9, Amount = 11.25m },
            new TransactionPortion { Id = 34, DebtorId = 19, TransactionId = 9, Amount = 11.25m },

            // Transaction 5: Percentage (Group 5, 3 members: 50%, 30%, 20%)
            new TransactionPortion { Id = 15, DebtorId = 15, TransactionId = 5, Amount = 45 },
            new TransactionPortion { Id = 16, DebtorId = 16, TransactionId = 5, Amount = 27 },
            new TransactionPortion { Id = 17, DebtorId = 17, TransactionId = 5, Amount = 18 }
        );
    }
}
