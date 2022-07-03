import { FormControl, Form, Button, InputGroup } from "react-bootstrap"
import { React, useState, useEffect } from 'react'
import { useDispatch } from 'react-redux';
import { SignUp } from '../services/authentication';

const SignInPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [username, setUsername] = useState('');

  const [confirmPassword, setConfirmPassword] = useState('');

  const dispatch = useDispatch();

  return <div style={{width:'30rem', margin:'auto', paddingTop: '8px'}}>
    <Form onSubmit={event => {
      event.preventDefault();
      SignUp(dispatch, {username, email, password})
    }}>
      <h4 style={{textAlign: 'center'}}> Welcome Back!</h4>
      <InputGroup className='mb-3'>
        <FormControl placeholder='Username' onChange={event => { setUsername(event.target.value)}}></FormControl>
      </InputGroup>

      <InputGroup className='mb-3'>
        <FormControl placeholder='Email' onChange={event => { setEmail(event.target.value)}}></FormControl>
      </InputGroup>

      <InputGroup className='mb-3'>
        <FormControl placeholder='Password' type='password' onChange={event => { setPassword(event.target.value)}}></FormControl>
      </InputGroup>

      <InputGroup className='mb-3'>
        <FormControl placeholder='Password' type='password' onChange={event => { setConfirmPassword(event.target.value)}}></FormControl>
      </InputGroup>
      <Button type='submit' variant='primary' style={{ margin: 'auto', display: 'block', width: '10rem' }} disabled={password !== confirmPassword || password.length < 1}>
        Sign Up
      </Button>

    </Form>
  </div>
}


export default SignInPage;
