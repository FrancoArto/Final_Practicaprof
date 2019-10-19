import React from 'react'
import { shallow } from 'enzyme';
import App from './App';

import Enzyme from "enzyme";
import Adapter from "enzyme-adapter-react-16";

Enzyme.configure({ adapter: new Adapter() });

it('renders without crashing', () => {
  const wrapper = shallow(<App />);
  expect(wrapper.find('.App').text()).toBe("1");
});
