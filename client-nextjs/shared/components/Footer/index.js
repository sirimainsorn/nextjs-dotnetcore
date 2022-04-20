import React from "react";

export default function Footer() {
  return (
    <div className="bg-gray-800">
      <div className="max-w-7xl mx-auto px-2 sm:px-6 lg:px-8">
        {/* menu footer */}
        <div className="py-6 lg:py-8 grid grid-cols-4 gap-4 text-gray-400">
          <div>
            <h2 className="font-bold">CONTACT US</h2>
          </div>
          <div className="flex flex-col gap-2">
            <h2 className="font-bold">INFORMATION</h2>
            <a className="text-sm">About Us</a>
            <a className="text-sm">Privacy Policy</a>
            <a className="text-sm">Contact Us</a>
          </div>
        </div>
        {/* copy right */}
        <div className="flex justify-between py-4 lg:py-6">
          <div>
            <h4 className="text-gray-400 text-sm">2020 Workflow</h4>
          </div>
          <div></div>
        </div>
      </div>
    </div>
  );
}
