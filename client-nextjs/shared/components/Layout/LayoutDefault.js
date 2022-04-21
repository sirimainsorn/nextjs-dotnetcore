import React from "react";
import { useSelector } from "react-redux";
import Footer from "../Footer";
import Header from "../Header";

export default function LayoutDefault(props) {
  const { children } = props;
  const { menuActive } = useSelector((state) => state.globalReducer);

  return (
    <div className="flex flex-col min-h-screen font-default">
      <Header menuActive={menuActive} />
      <main className="flex-grow">{children}</main>
      <Footer />
    </div>
  );
}
