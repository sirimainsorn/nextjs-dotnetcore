import React from "react";

export default function TopHeader() {
  return (
    <div className="bg-gray-900">
      <div className="max-w-7xl mx-auto px-2 sm:px-6 lg:px-8 py-2">
        <div className="flex justify-between text-white text-xs">
          <h5>(+66) 99 123 0000</h5>
          <div className="flex divide-x">
            <span className="px-3">Login</span>
            <span className="px-3">Register</span>
          </div>
        </div>
      </div>
    </div>
  );
}
