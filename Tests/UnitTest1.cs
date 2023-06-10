using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortfolioService.Controllers;
using PortfolioService.Data;
using PortfolioService.Dtos;
using PortfolioService.Models;
using Xunit;

namespace Tests;

public class UnitTest1
{
    private readonly Mock<IPortfolioRepo> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly PortfoliosController _controller;

    public UnitTest1()
    {
        _mockRepo = new Mock<IPortfolioRepo>();
        _mockMapper = new Mock<IMapper>();
        _controller = new PortfoliosController(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public void GetPortfolioByUserId_ValidUserId_ReturnsOkResultWithPortfolios()
    {
        // Arrange
        var userId = "testUser";
        var portfolios = new List<Portfolio>
        {
            new Portfolio { Id = 1, TradeId = 1, UserId = userId, Name = "Portfolio 1", Amount = 100, Price = 10 },
            new Portfolio { Id = 2, TradeId = 2, UserId = userId, Name = "Portfolio 2", Amount = 200, Price = 20 }
        };

        _mockRepo.Setup(repo => repo.GetPortfolioByUserId(userId)).Returns(portfolios);

        var mappedPortfolios = portfolios.Select(p => new PortfolioReadDto
        {
            Id = p.Id,
            TradeId = p.TradeId,
            UserId = p.UserId,
            Name = p.Name,
            Amount = p.Amount,
            Price = p.Price
        });

        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PortfolioReadDto>>(portfolios))
            .Returns(mappedPortfolios);

        // Act
        var result = _controller.GetPortfolioByUserId(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedPortfolios = Assert.IsAssignableFrom<IEnumerable<PortfolioReadDto>>(okResult.Value);
        Assert.Equal(portfolios.Count, returnedPortfolios.Count());
    }

    [Fact]
    public void GetPortfolioByUserId_InvalidUserId_ReturnsNotFoundResult()
    {
        // Arrange
        var userId = "nonexistentUser";
        _mockRepo.Setup(repo => repo.GetPortfolioByUserId(userId)).Returns((IEnumerable<Portfolio>)null);

        // Act
        var result = _controller.GetPortfolioByUserId(userId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void CreatePortfolio_ValidDto_ReturnsCreatedAtRouteResult()
    {
        // Arrange
        var portfolioCreateDto = new PortfolioCreateDto
        {
            TradeId = 1,
            UserId = "testUser",
            Name = "New Portfolio",
            Amount = 100,
            Price = 10
        };

        var portfolioModel = new Portfolio
        {
            Id = 1,
            TradeId = portfolioCreateDto.TradeId,
            UserId = portfolioCreateDto.UserId,
            Name = portfolioCreateDto.Name,
            Amount = portfolioCreateDto.Amount,
            Price = portfolioCreateDto.Price
        };

        var portfolioReadDto = new PortfolioReadDto
        {
            Id = portfolioModel.Id,
            TradeId = portfolioModel.TradeId,
            UserId = portfolioModel.UserId,
            Name = portfolioModel.Name,
            Amount = portfolioModel.Amount,
            Price = portfolioModel.Price
        };

        _mockMapper.Setup(mapper => mapper.Map<Portfolio>(portfolioCreateDto))
            .Returns(portfolioModel);

        _mockRepo.Setup(repo => repo.CreatePortfolio(portfolioModel));

        _mockMapper.Setup(mapper => mapper.Map<PortfolioReadDto>(portfolioModel))
            .Returns(portfolioReadDto);

        // Act
        var result = _controller.CreatePortfolio(portfolioCreateDto);

        // Assert
        var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
        Assert.Equal(nameof(PortfoliosController.GetPortfolioByUserId), createdAtRouteResult.RouteName);
        Assert.Equal(portfolioReadDto.Id, createdAtRouteResult.RouteValues["Id"]);
        Assert.Equal(portfolioReadDto, createdAtRouteResult.Value);
    }
}