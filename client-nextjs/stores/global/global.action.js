export const GlobalActions = {
  spinnerLoading,
};

function spinnerLoading(payload) {
  return {
    type: "SPINNER_LOADING",
    payload,
  };
}
