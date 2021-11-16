import { configureStore } from '@reduxjs/toolkit';
import expensesSlice from './expensesSlice';
import ToastMiddleware from '../middleware/ToastMiddleware';

export const store = configureStore({
  reducer: {
    expensesSlice: expensesSlice
   },
   middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(ToastMiddleware)
});
