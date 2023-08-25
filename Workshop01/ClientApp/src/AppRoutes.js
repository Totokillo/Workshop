import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Layout } from './components/Layout';
import Login from "./pages/login";
import Register from "./pages/register";
import Home from "./pages/home";
import Profile from "./pages/profile";

const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/register',
    element: <Register />
  },
  {
    path: '/home',
    element: <Layout><Home /></Layout>
  },
  {
    path: '/profile',
    element: <Layout><Profile /></Layout>
  },
  {
    path: '/counter',
    element: <Layout><Counter /></Layout>
  },
  {
    path: '/fetch-data',
    element: <Layout><FetchData /></Layout>
  }
];

export default AppRoutes;
