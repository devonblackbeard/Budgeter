import { setExpenses, createExpense, editExpense, deleteExpense } from '../app/expensesSlice'
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
  }
}

export const EditExpense = async (dispatch, expense) => {
  try {
    await axiosInstance.put('', expense);

    dispatch(editExpense(expense))
  } catch (error) {
    console.log('error in edit')
  }
}

export const DeleteExpense = async (dispatch, expense) => {
  try {
    // api call
    await axiosInstance.delete('', {data: {...expense} });

    dispatch(deleteExpense(expense))
  } catch (error) {
    console.log('error in delete')
  }
}
