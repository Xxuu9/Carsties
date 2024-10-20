using System;

namespace AuctionService.DTOs;

public class AuctionDto
{
    //a combination of the auction and item entities
    public Guid Id{get;set;}
    public int ReservePrice{get;set;}

    public string Seller{get;set;}

    public string Winnder{get;set;}

    public int SoldAmount{get;set;}

    public int CurrentHighBid{get;set;}

    //no default value
    public DateTime CreateAt{get;set;}

    public DateTime UpdateAt{get;set;}

    public DateTime AuctionEnd{get;set;}

    public string Status{get;set;}

    public string Make{get;set;}

    public string Model{get;set;}

    public int Year{get;set;}

    public string Color{get;set;}

    public int Mileage{get;set;}

    public string ImageUrl{get;set;}

}
