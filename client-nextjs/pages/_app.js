import Router from "next/router";
import { useEffect, useState } from "react";
import { Provider } from "react-redux";
import Loading from "../shared/components/Loading";
import { stores } from "../stores";

import "../styles/globals.css";
import "../styles/loading.css";

function MyApp({ Component, pageProps }) {
  const Layout = Component.layout || (({ children }) => <>{children}</>);
  const [isLoading, setLoadingState] = useState(false);

  useEffect(() => {
    const start = () => {
      setLoadingState(true);
    };
    const end = () => {
      setLoadingState(false);
    };

    Router.events.on("routeChangeStart", start);
    Router.events.on("routeChangeComplete", end);
    Router.events.on("routeChangeError", end);
    return () => {
      Router.events.off("routeChangeStart", start);
      Router.events.off("routeChangeComplete", end);
      Router.events.off("routeChangeError", end);
    };
  }, []);

  return (
    <Provider store={stores}>
      <Layout>
        {isLoading && <Loading />}
        <Component {...pageProps} />
      </Layout>
    </Provider>
  );
}

MyApp.getInitialProps = async ({ Component, router, ctx }) => {
  let pageProps = {};
  console.log(router);

  if (Component.getInitialProps) {
    pageProps = await Component.getInitialProps(ctx);
  }

  return { pageProps };
};

export default MyApp;
