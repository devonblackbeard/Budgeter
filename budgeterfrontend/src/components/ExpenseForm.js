import { Form, Row, Col, Button } from 'react-bootstrap'
import { React, useState, useEffect } from 'react'
import { CreateExpense, DeleteExpense, EditExpense } from '../services/expenses';
import { useDispatch } from 'react-redux'


export default ({expense, setIsEditing}) => {
  const descriptions = ['Groceries', 'Credit Card', 'Student Loans', 'Eating out', 'Gas']
  const [amount, setAmount] = useState(0);
  const [description, setDescription] = useState(descriptions[0]);
  const [isNewExpense, setIsNewExpense] = useState(true);
  const dispatch = useDispatch();

  useEffect(() => {
    if(expense !== undefined){
      setIsNewExpense(false);
      setAmount(expense.amount);
      setDescription(expense.description);
      
    }
    else{
      setIsNewExpense(true);
    }
  }, [expense])  // run this use effect every time expense changes

  return <Form onSubmit={event=> {event.preventDefault();
    if(isNewExpense){
      // create a new expense
      CreateExpense(dispatch, {description: description, amount: amount});

    }
    else{
      // edit expense
      EditExpense(dispatch, {id: expense.id, description: description, amount: amount})
      setIsEditing(false)
    }

  }}>
    <Row>
      <Col>
        <Form.Label>Description</Form.Label>
        <Form.Control as='select' onChange={event => { console.log(event.target.value); setDescription(event.target.value)}}>
          {descriptions.map(d=> <option key={d}>{d}</option>)}
        </Form.Control>
      </Col>

      <Col>
      <Form.Label>Amount</Form.Label>
        <Form.Control type='number' step='0.01' placeholder={amount} onChange= {event => setAmount(event.target.value)} ></Form.Control>
      </Col>
      <Col>
      <div style={{ marginTop: '2rem'}}>
        {isNewExpense ? <Button variant='primary' type='submit'> Add </Button> :
        <div>
          <Button style={{marginRight: '2px'}} variant='danger' onClick={()=> DeleteExpense(dispatch, expense)}>Delete</Button>
          <Button variant='success' type='submit'>Save</Button>
          <Button variant='default' onClick={()=> setIsEditing(false)}>Cancel</Button>
        </div>}
      </div>
      </Col>
    </Row>
  </Form>
}


