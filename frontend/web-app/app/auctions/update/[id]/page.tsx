import { getDetailedViewData } from "@/app/actions/auctionActions";
import React from "react";
import AuctionForm from "../../AuctionForm";
import Heading from "@/app/components/Heading";

export default async function Details({ params }: { params: { id: string } }) {
  const data = await getDetailedViewData(params.id);
  return (
    <div className="mx-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg">
      <Heading
        title="Update your acution"
        subtitle="Please update the details of your car"
      />
      <AuctionForm auction={data} />
    </div>
  );
}