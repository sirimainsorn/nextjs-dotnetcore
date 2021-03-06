export const GlobalReducer = (
  state = {
    loading: false,
    menuActive: "/",
  },
  action
) => {
  switch (action.type) {
    case "SPINNER_LOADING":
      return {
        ...state,
        loading: action.payload.isOpen,
      };

    default:
      return state;
  }
};
