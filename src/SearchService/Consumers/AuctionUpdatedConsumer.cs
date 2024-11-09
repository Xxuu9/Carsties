using System;
using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

using System.Text.Json;

namespace SearchService.Consumers;

public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
{
    private readonly IMapper _mapper;

    public AuctionUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
        string rawJsonData = await new StreamReader(context.ReceiveContext.GetBodyStream()).ReadToEndAsync();
        Console.WriteLine("Raw JSON data received: " + rawJsonData);
        Console.WriteLine("--> Consuming auction updated: "+context.Message.Id);
        Console.WriteLine("--> Consuming auction updated: 》〉》"+context.Message);

Console.WriteLine(JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { WriteIndented = true }));

        var item = _mapper.Map<Item>(context.Message);

        Console.WriteLine("--> Consuming auction >>>>>>>>>: "+item.ID+item.Make+item.Color+item.Model+item.Year+item.Mileage);

        var result = await DB.Update<Item>()
        .Match(a => a.ID == context.Message.Id)
        .ModifyOnly(x => new
        {
            x.Color,
            x.Make,
            x.Model,
            x.Year,
            x.Mileage
        }, item)
        .ExecuteAsync();

        if(!result.IsAcknowledged)
            throw new MessageException(typeof(AuctionUpdated),"Problem updating mongodb");
    }
}
