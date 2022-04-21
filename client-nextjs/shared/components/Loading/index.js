import React from "react";

export default function Loading() {
  return (
    <div className="bg-blue-100 bg-opacity-20 fixed z-40 w-screen h-screen flex items-center justify-center top-0 left-0">
      <i className="loading-spinner loading"></i>
    </div>
  );
}
