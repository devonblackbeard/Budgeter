import { useDispatch, useSelector } from 'react-redux';
import { Nav, Button, Form } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import { logout } from '../app/authenticationSlice';
import { React } from 'react';


const Navbar = ({u}) => {
const { isLoggedIn } = useSelector(state => state.authenticationSlice);
const dispatch = useDispatch();

  return <Nav className='navbar' style={{ backgroundColor: '#e4ff2'}}>
    <h1 style={{ fontFamily: 'Brush Script MT'}}>My Expenses</h1>
    {
      isLoggedIn ? <div><Button variant='link' href='/signin' onClick={ () => dispatch(logout() )}>Log Out</Button>User: <Form.Label>{u}</Form.Label></div>
      : <div style={{ display: 'flex'}}>
        <NavLink to='/signup'>Sign Up</NavLink>
        <NavLink to='/signin' style={{marginLeft:'1rem'}}>Sign In</NavLink>
      </div>
    }

  </Nav>
}


export default Navbar;
