﻿namespace BugStore.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
