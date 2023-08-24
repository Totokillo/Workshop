import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Layout } from './components/Layout';
import Login from "./pages/login";
import Register from "./pages/register";

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
    path: '/counter',
    element: <Layout><Counter /></Layout>
  },
  {
    path: '/fetch-data',
    element: <Layout><FetchData /></Layout>
  }
];

export default AppRoutes;
