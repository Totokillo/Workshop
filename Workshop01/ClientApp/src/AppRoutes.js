import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Layout } from './components/Layout';
import { Home } from './components/Home';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/home',
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
