import { createSlice } from '@reduxjs/toolkit'

export const authenticationSlice = createSlice({
  name: 'authentication',
  initialState: {
    token: '',
    isLoggedIn: false,
  },
  reducers: {
    userAuthenticated: (state, action) => {
      console.log('saving token... authenticated', action);

      sessionStorage.setItem('token', action.payload.token)
      return {
        ...state, ...{
          token: action.payload.token,
          isLoggedIn: true,
          username: action.payload.username
        }
      }
    },
    logout: () => {
      sessionStorage.clear();
    }
  }
})


export const {userAuthenticated, logout} = authenticationSlice.actions;
export default authenticationSlice.reducer;
