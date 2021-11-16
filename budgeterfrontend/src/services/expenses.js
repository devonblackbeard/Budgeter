import { setExpenses, createExpense, editExpense, deleteExpense, setExpensesError, editExpenseError, deleteExpenseError, createExpenseError } from '../app/expensesSlice'
import * as axios from 'axios'

const axiosInstance = axios.create({
  baseURL: 'https://localhost:5001/budget'
})

export const GetExpenses = async (dispatch) => {
  try {
    // api call
    const {data} = await axiosInstance.get()
    console.log(data)
    dispatch(setExpenses(data));

  } catch (error) {
    console.log('Error')
    dispatch(setExpensesError());
  }
}

export const CreateExpense = async (dispatch, expense) => {
  try {
    // api call
    console.log('dispatch: ', dispatch )
    const { data } = await axiosInstance.post('', expense);
    dispatch(createExpense(data))
  } catch (error) {
    console.log('in error', error)
    dispatch(createExpenseError());

  }
}

export const EditExpense = async (dispatch, expense) => {
  try {
    await axiosInstance.put('', expense);

    dispatch(editExpense(expense))
  } catch (error) {
    console.log('error in edit')
    dispatch(editExpenseError());

  }
}

export const DeleteExpense = async (dispatch, expense) => {
  try {
    // api call
    await axiosInstance.delete('', {data: {...expense} });

    dispatch(deleteExpense(expense))
  } catch (error) {
    console.log('error in delete')
    dispatch(deleteExpenseError());

  }
}
