import { ActionCreators } from '../app/expensesReducer'

export const GetExpenses = async (dispatch) => {
  try {
    // api call
    const expenses = [
      {
        id: 1, description: 'Groceries', amount: 23.16
      },
      {
        id: 2, description: 'Gas', amount: 21.00
      },
      {
        id: 3, description: 'Student Loans', amount: 18.50
      }
    ]
    dispatch(ActionCreators.setExpenses(expenses));

  } catch (error) {
    console.log('Error')

  }
}

export const CreateExpense = async (dispatch, expense) => {
  try {
    // api call
    console.log('dispatch: ', dispatch )
    dispatch(ActionCreators.createExpense({id:10, description: expense.description, amount: expense.amount }))
  } catch (error) {
    console.log('in error', error)
  }
}

export const EditExpense = async (dispatch, expense) => {
  try {
    dispatch(ActionCreators.editExpense(expense))
  } catch (error) {
    console.log('error in edit')
  }
}

export const DeleteExpense = async (dispatch, expense) => {
  try {
    // api call
    dispatch(ActionCreators.deleteExpense(expense))
  } catch (error) {
    console.log('error in delete')
  }
}
