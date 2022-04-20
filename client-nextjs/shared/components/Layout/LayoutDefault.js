import React from "react";
import Footer from "../Footer";
import Header from "../Header";

export default function LayoutDefault(props) {
  const { children } = props;

  return (
    <div className="flex flex-col min-h-screen font-default">
      <Header />
      <main className="flex-grow">{children}</main>
      <Footer />
    </div>
  );
}
