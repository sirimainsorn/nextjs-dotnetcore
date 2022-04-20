import { combineReducers } from "redux";
import { GlobalReducer } from "./global/global.reducer";

export const Reducers = combineReducers({
  globalReducer: GlobalReducer,
});
