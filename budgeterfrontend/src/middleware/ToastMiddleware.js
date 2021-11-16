import { createExpense, editExpense, deleteExpense, setExpensesError, editExpenseError, deleteExpenseError, createExpenseError} from '../app/expensesSlice';
import { toast } from 'react-toastify';

const ToastMiddleware = () => next => action => {
  switch (action.type) {
    case createExpense.type:
      toast.success('New expense added successfully')
      break;
    case editExpense.type:
      toast.success('Expense edited successfully')
      break;
    case deleteExpense.type:
      toast.success('Expense deleted added successfully')
      break;
    case setExpensesError.type:
      toast.error('Error loading expenses')
      break;
    case editExpenseError.type:
      toast.error('Error Editing expenses')
      break;
    case deleteExpenseError.type:
      toast.error('Error deleting expenses')
      break;
    case createExpenseError.type:
      toast.error('Error creating expenses')
      break;
    default:
      break;
  }
  return next(action);
}

export default ToastMiddleware;
