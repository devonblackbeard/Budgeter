import SignInPage from './components/SignInPage';
import SignUpPage from './components/SignUpPage';
import HomePage from './components/HomePage';
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { useEffect } from 'react';
import { userAuthenticated } from './app/authenticationSlice';
import Navbar from './components/Navbar';

const App = () => {

  const {isLoggedIn, username} = useSelector(state=> state.authenticationSlice);
  const dispatch = useDispatch();

  useEffect(() => {
    const token = sessionStorage.getItem('token');
    if(token !== null && token !== undefined)
    {
      dispatch(userAuthenticated({token}));
    }
  }, []);

  return <BrowserRouter>
    <Navbar u={username}/>
    <Routes>
      <Route path='/' element={isLoggedIn ? <HomePage /> : <SignInPage />} />
      <Route path='/signup' element={ isLoggedIn ? <Navigate to='/' /> : <SignUpPage />} />
      <Route path='/signin' element={ isLoggedIn ? <Navigate to='/' /> : <SignInPage />} />
      <Route element={<h2> Page Not Found !! </h2>} />
    </Routes>
  </BrowserRouter>
}

export default App;

