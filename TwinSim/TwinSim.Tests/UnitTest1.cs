using System;
using System.Linq;
using TwinSim.Domain.Models;
using TwinSim.Services;
using Xunit;

namespace TwinSim.Tests;

public class TwinServiceTests
{
    private readonly TwinService _service;

    public TwinServiceTests()
    {
        _service = new TwinService();
    }

    [Fact]
    public void GetAll_ShouldReturnInitialData()
    {
        var all = _service.GetAll();

        Assert.NotNull(all);
        Assert.NotEmpty(all);
        Assert.All(all, twin => Assert.NotEqual(Guid.Empty, twin.Id));
    }

    [Fact]
    public void GetById_ShouldReturnCorrectTwinObject()
    {
        var existing = _service.GetAll().First();
        var fetched = _service.GetById(existing.Id);

        Assert.NotNull(fetched);
        Assert.Equal(existing.Id, fetched.Id);
        Assert.Equal(existing.Name, fetched.Name);
    }

    [Fact]
    public void GetById_ShouldReturnNullForUnknownId()
    {
        var unknownId = Guid.NewGuid();
        var result = _service.GetById(unknownId);

        Assert.Null(result);
    }

    [Fact]
    public void Create_ShouldAddNewTwinObject()
    {
        var newTwin = new TwinObject { Name = "Test Twin" };

        var created = _service.Create(newTwin);

        Assert.NotNull(created);
        Assert.NotEqual(Guid.Empty, created.Id);
        Assert.Equal("Test Twin", created.Name);

        var fetched = _service.GetById(created.Id);
        Assert.NotNull(fetched);
        Assert.Equal(created.Id, fetched.Id);
    }

    [Fact]
    public void Update_ShouldModifyExistingTwinObject()
    {
        var original = _service.GetAll().First();
        var updatedTwin = new TwinObject { Name = "Updated Name" };

        var updated = _service.Update(original.Id, updatedTwin);

        Assert.NotNull(updated);
        Assert.Equal(original.Id, updated.Id);
        Assert.Equal("Updated Name", updated.Name);
    }

    [Fact]
    public void Update_ShouldReturnNullForUnknownId()
    {
        var unknownId = Guid.NewGuid();
        var updated = _service.Update(unknownId, new TwinObject { Name = "Nobody" });

        Assert.Null(updated);
    }

    [Fact]
    public void Delete_ShouldRemoveTwinObject()
    {
        var toDelete = _service.GetAll().First();

        var deleted = _service.Delete(toDelete.Id);

        Assert.True(deleted);
        Assert.Null(_service.GetById(toDelete.Id));
    }

    [Fact]
    public void Delete_ShouldReturnFalseForUnknownId()
    {
        var unknownId = Guid.NewGuid();
        var deleted = _service.Delete(unknownId);

        Assert.False(deleted);
    }
}
