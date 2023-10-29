import {
    createBrowserRouter,
    Route,
    RouterProvider,
    Routes,
} from 'react-router-dom';

import NotFound from '@/pages/not-found';
import Home from '@/pages/home';
import Login from '@/pages/login';
import Register from '@/pages/register';

const router = createBrowserRouter([
    { path: '*', Component: Root },
    { path: '/', Component: Home },
]);

function App() {
    return <RouterProvider router={router} />;
}

function Root() {
    return (
        <Routes>
            <Route path="*" element={<NotFound />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
        </Routes>
    );
}

export default App;
