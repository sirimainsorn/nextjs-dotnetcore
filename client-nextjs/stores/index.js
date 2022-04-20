import { createStore, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";
import { Reducers } from "./reducer";

export const stores = createStore(Reducers, applyMiddleware(thunkMiddleware));
